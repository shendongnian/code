        public enum Props
        {
            A, B, C, Color, Type, Region, Centre, Angle
        }
        public SpecularProperties()
            :base("SpecularProperties", null)
        {
            Create<double>(1, Props.A);
            Create<double>(1, Props.B);
            Create<double>(1, Props.C);
            Create<Color>(Color.Gray, Props.Color);
            Create<GradientType>(GradientType.Linear, Props.Type);
            Create<RectangleF>(RectangleF.Empty, Props.Region);
            Create<PointF>(PointF.Empty, Props.Centre);
            Create<float>(0f, Props.Angle);
        }
