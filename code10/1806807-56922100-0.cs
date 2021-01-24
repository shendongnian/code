csharp
/// <summary>
/// THE layout control. Support layout, edge routing and overlap removal algorithms, with multiple layout states.
/// </summary>
/// <typeparam name="TVertex">Type of the vertices.</typeparam>
/// <typeparam name="TEdge">Type of the edges.</typeparam>
/// <typeparam name="TGraph">Type of the graph.</typeparam>
public partial class GraphLayout<TVertex, TEdge, TGraph>
    where TVertex : class
    where TEdge : IEdge<TVertex>
    where TGraph : class, IBidirectionalGraph<TVertex, TEdge>
{
