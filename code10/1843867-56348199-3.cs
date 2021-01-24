    using System.Collections.Generic;
    using System.Linq;
    using GraphFastPath.GraphData;
    namespace GraphFastPath
    {
        public class BranchNBound
        {
            public static BranchNBound Instance;
            private readonly Graph _graph;
            public bool _ignoreDeadEnds;
            public SortedDictionary<float, List<BbIterationStep>> _iterations = new SortedDictionary<float, List<BbIterationStep>>();
            public List<BbIterationStep> BestPath = new List<BbIterationStep>();
            public int IdCounter;
            public int MaxNodesVisited;
            public BbIterationStep PathNode;
            public BranchNBound(Graph graph, bool ignoreDeadEnds)
            {
                _graph = graph;
                _ignoreDeadEnds = ignoreDeadEnds;
                Instance = this;
                var nodesCount = ignoreDeadEnds ? _graph.Nodes.Count(x => !x.IsDeadEnd) : _graph.Nodes.Count;
                foreach (var edge in _graph.Nodes[0].Edges)
                    AddStep(new BbIterationStep(edge, nodesCount), 1000);
            }
            public int IterationsCount => _iterations.Sum(x => x.Value.Count);
            public void RegisterGoodPath(BbIterationStep step)
            {
                if (step._uniqPassedNodesCount < MaxNodesVisited)
                    return;
                if (step._uniqPassedNodesCount > MaxNodesVisited)
                {
                    BestPath.Clear();
                    MaxNodesVisited = step._uniqPassedNodesCount;
                }
                BestPath.Add(step);
            }
            public void DoStep()
            {
                var min = _iterations.Last();
                var list = min.Value;
                _iterations.Remove(min.Key);
                foreach (var step in list)
                    step.DoStep();
            }
            public void AddStep(BbIterationStep step, float cost)
            {
                step.VariantId = IdCounter++;
                if (!_iterations.TryGetValue(cost, out var list))
                {
                    list = new List<BbIterationStep>();
                    _iterations.Add(cost, list);
                }
                list.Add(step);
            }
        }
        public class BbIterationStep
        {
            private readonly int _totalNodesCount;
            private readonly Edge _currentEdge;
            private int _totalPassedNodesCount;
            public int _uniqPassedNodesCount;
            public string Debug;
            public List<Node> LocalPath = new List<Node>();
            public Node Node;
            public BbIterationStep Parent;
            public float Score;
            public int VariantId;
            public BbIterationStep(Edge currentEdge, int nodesCount)
            {
                _currentEdge = currentEdge;
                _totalNodesCount = nodesCount;
                Node = _currentEdge.From;
                _uniqPassedNodesCount++;
                _totalPassedNodesCount++;
            }
            public BbIterationStep(BbIterationStep from, Edge currentEdge, string debug, float score)
            {
                Parent = from;
                Score = score;
                _currentEdge = currentEdge;
                Debug = debug;
                Node = _currentEdge.From;
                _uniqPassedNodesCount = from._uniqPassedNodesCount;
                _totalPassedNodesCount = from._totalPassedNodesCount;
                _totalNodesCount = from._totalNodesCount;
            }
            public int Id => _currentEdge.From.Id;
            public Node NodeTo => _currentEdge.To;
            public void DoStep()
            {
                _currentEdge.Pass(false);
                _currentEdge.To.SetProcessed();
                var passed = CheckPassed(_currentEdge.To);
                if (!passed)
                {
                    _uniqPassedNodesCount++;
                    if (BranchNBound.Instance.MaxNodesVisited < _uniqPassedNodesCount)
                        BranchNBound.Instance.RegisterGoodPath(this);
                    if (_uniqPassedNodesCount == _totalNodesCount)
                        BranchNBound.Instance.PathNode = this;
                }
                _totalPassedNodesCount++;
                var totalDistFromStartMin = float.MaxValue;
                var totalDistFromStartMax = float.MinValue;
                foreach (var edge in _currentEdge.To.Edges)
                {
                    var dist = edge.To.DistanceFromStart;
                    var nextNodePassedCount = CountPassed(edge.To);
                    if (nextNodePassedCount > 0)
                        dist *= nextNodePassedCount + 2;
                    if (totalDistFromStartMin > dist)
                        totalDistFromStartMin = dist;
                    if (totalDistFromStartMax < dist)
                        totalDistFromStartMax = dist;
                }
                var delta = totalDistFromStartMax - totalDistFromStartMin;
                if (delta == 0)
                    delta = totalDistFromStartMax;
                foreach (var edge in _currentEdge.To.Edges)
                {
                    if (BranchNBound.Instance._ignoreDeadEnds && edge.To.IsDeadEnd)
                        continue;
                    var deltaGoodFromStart = 1 - (edge.To.DistanceFromStart - totalDistFromStartMin) / delta; // + float.Epsilon;
                    if (float.IsNaN(deltaGoodFromStart))
                    {
                        var test = 1;
                    }
                    MoveNextEdge(edge, deltaGoodFromStart);
                }
            }
            private void MoveNextEdge(Edge edge, float deltaGoodFromStart)
            {
                var nextNodePassedCount = CountPassed(edge.To);
                var progressScale = (float) _uniqPassedNodesCount / _totalNodesCount; //weight 200    :Total path search progress (how much it is completed/finished)
                var nextNodeScoreScale = 1f / (nextNodePassedCount * nextNodePassedCount + 1); //weight 200    :Lower value if next node was visited more times
                var pc = _uniqPassedNodesCount;
                if (nextNodePassedCount == 0)
                    pc++;
                var pathNoRepeatedNodesScoreScale = (float) pc / (_totalPassedNodesCount + 1); //weight 400    :Higher value if all nodes was visited less times
                var progressScaleValue = progressScale * 1;
                var nextNodeScoreValue = nextNodeScoreScale * 300;
                var deltaGoodFromStartValue = deltaGoodFromStart * 500 * nextNodeScoreScale;
                var pathNoRepeatedNodesScoreValue = pathNoRepeatedNodesScoreScale * 800;
    			 //iterations with bigger score will be processed earlier
                var totalScore = progressScaleValue +
                                 nextNodeScoreValue +
                                 deltaGoodFromStartValue +
                                 pathNoRepeatedNodesScoreValue;
                var dbg = $"Progress: {progressScaleValue} NextNode({edge.To.Id}): {nextNodeScoreValue} GoodStart: {deltaGoodFromStartValue} NoRepeat: {pathNoRepeatedNodesScoreValue}";
                var newStep = new BbIterationStep(this, edge, dbg, totalScore);
                BranchNBound.Instance.AddStep(newStep, totalScore);
            }
            public bool CheckPassed(Node node)
            {
                var checkStep = this;
                do
                {
                    if (checkStep.Node == node)
                        return true;
                    checkStep = checkStep.Parent;
                } while (checkStep != null);
                return false;
            }
            public void GetPathEdges(List<Edge> result)
            {
                var checkStep = this;
                do
                {
                    result.Add(checkStep._currentEdge);
                    checkStep = checkStep.Parent;
                } while (checkStep != null);
            }
            private int CountPassed(Node node)
            {
                var passedCount = 0;
                var checkStep = this;
                do
                {
                    if (checkStep.Node == node)
                        passedCount++;
                    checkStep = checkStep.Parent;
                } while (checkStep != null);
                return passedCount;
            }
            public override string ToString()
            {
                return Parent == null ? Id.ToString() : $"({Score}) ({VariantId}), {Debug}";
            }
            public string GetPath()
            {
                return Parent == null ? Id.ToString() : $"{Parent.GetPath()}-{Id}";
            }
        }
    }
