     public TypedLabel(LabelType type)
            : base()
        {
            pb.Image = GetImageFromType(type, this.LabelColor);
        }
