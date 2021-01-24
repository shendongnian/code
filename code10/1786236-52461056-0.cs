    class MyTextEmbeddedObject : TextEmbeddedObject
    {
        public override LineBreakCondition BreakBefore => LineBreakCondition.BreakAlways;
        public override LineBreakCondition BreakAfter => LineBreakCondition.BreakRestrained;
        public override bool HasFixedSize => true;
        public override CharacterBufferReference CharacterBufferReference => throw new NotImplementedException();
        public override int Length => 1;
        public override TextRunProperties Properties => GenericTextParagraphProperties._defaultTextRunProperties;
        public override Rect ComputeBoundingBox(bool rightToLeft, bool sideways)
        {
            throw new NotImplementedException();
        }
        public override void Draw(DrawingContext drawingContext, Point origin, bool rightToLeft, bool sideways)
        {
            throw new NotImplementedException();
        }
        public override TextEmbeddedObjectMetrics Format(double remainingParagraphWidth)
        {
            return new TextEmbeddedObjectMetrics(10000 /* very wide width */, 0, 0);
        }
    }
