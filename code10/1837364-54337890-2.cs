     public class GlowStruct : Colour
        {
            public bool RWO { get; } = true;
            public bool RWUO { get; } = true;
            public void Inherit(Colour Parent)
            {
                R = Parent.R;
                G = Parent.G;
                B = Parent.B;
                A = Parent.A;
            }
        }
