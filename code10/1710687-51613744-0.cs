    class Model : IDisposable
    {
        TFSession _session;
        TFGraph _graph;
        TFOutput _input;
        TFOutput _output;
        LinearLayer _y_out;
        TFOutput _cost;
        TFTensor _dataX;
        TFTensor _dataY;
        GradientDescentOptimizer _gradientDescentOptimizer;
        public Model()
        {
            float[,] aX = LoadCsv("dataX.csv");
            float[,] aY = LoadCsv("dataY.csv");
            _dataX = new TFTensor(aX);
            _dataY = new TFTensor(aY);
            
            _session = new TFSession();
            _graph = _session.Graph;
            _input = _graph.Placeholder(TFDataType.Float);
            _output = _graph.Placeholder(TFDataType.Float);
            _y_out = new LinearLayer(_graph, _input, (int)_dataX.Shape[0], 1);
            cost = _graph.ReduceMean(_graph.SigmoidCrossEntropyWithLogits(_y_out.Result, _output));
            _gradientDescentOptimizer = new GradientDescentOptimizer(_graph, _cost, _y_out.W, _y_out.b);
            _gradientDescentOptimizer.ApplyGradientDescent(_graph);
            var runner = _session.GetRunner();
                        
            runner.AddTarget(_y_out.InitB.Operation);
            runner.Run();
        }
        public void TrainModelIteration()
        {
            var runner = _session.GetRunner();
            runner.AddInput(_input, _dataX);
            runner.AddInput(_output, _dataY);
            for (int i = 0; i < 2; i++)
            {
                runner.Fetch(_gradientDescentOptimizer.Updates[i]);
            }
            runner.Run();
        }
        public void Dispose()
        {
            _graph.Dispose();
            _session.Dispose();
        }
    }
    class LinearLayer
    {
        public TFOutput Result { get; set; }
        public TFOutput W { get; set; }
        public TFOutput b { get; set; }
        public TFOutput InitW { get; set; }
        public TFOutput InitB { get; set; }
        public LinearLayer(TFGraph graph, TFOutput x, int inSize, int outSize)
        {
            var wShape = new TFShape(inSize, outSize);
            W = graph.VariableV2(wShape, TFDataType.Float);
            TFOutput tfOutputWShape = graph.Const(wShape);
            TFOutput initialW = graph.RandomUniform(tfOutputWShape, TFDataType.Float);
            InitW = graph.Assign(W, initialW);
            var bShape = new TFShape(outSize);
            b = graph.VariableV2(bShape, TFDataType.Float);
            TFOutput tfOutputBShape = graph.Const(bShape);
            TFOutput initialB = graph.RandomUniform(tfOutputBShape, TFDataType.Float);
            InitB = graph.Assign(b, initialB);
            var matMul = graph.MatMul(x, W);
            Result = graph.Add(matMul, b);
        }
    }
    class GradientDescentOptimizer
    {
        private TFOutput[] _variables;
        public TFOutput[] Updates { get; set; }
        private TFOutput[] _gradients;
        public GradientDescentOptimizer(TFGraph graph, TFOutput grad, TFOutput w, TFOutput b)
        {
            _variables = new TFOutput[4];
            _variables[0] = w;
            _variables[1] = b;
            _gradients = graph.AddGradients(new TFOutput[] { grad }, new TFOutput[] { w, b });
            Updates = new TFOutput[4];
        }
        public void ApplyGradientDescent(TFGraph graph, float alpha = 0.01f)
        {
            TFOutput tfAlpha = graph.Const(alpha);
            for (int i = 0; i < 2; i++)
            {
                Updates[i] = graph.ApplyGradientDescent(_variables[i], tfAlpha, _gradients[i]);
            }
        }
    }
