    class PainterCrew : IPainter
    {
        readonly IEnumerable<IPainter> painters;
        PainterCrew(IEnumerable<IPainter> painters)
        {
            this.painters = painters;
        }
        double PaintedArea(double hours)
        {
            return this.painters.Sum(p => p.PaintedArea(hours));
        }
    }
