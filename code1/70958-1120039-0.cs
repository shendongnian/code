    using System.Runtime.InteropServices;
    using System.Drawing;
    
    namespace example_namespace
    {
    
        [Guid("1F436D05-1111-3340-8050-E70166C7FC86")]    
        public interface Circle_interface
        {
    
            [DispId(1)]
            int Radius
            {
                get;
                set;
            }
    
            [DispId(2)]
            int X
            {
                get;
                set;
            }
    
            [DispId(3)]
            int Y
            {
                get;
                set;
            }
    
        }
    
    
        [Guid("4EDA5D35-1111-4cd8-9EE8-C543163D4F75"),
            ProgId("example_namespace.Circle_interface"),
            ClassInterface(ClassInterfaceType.None)]
        public class Circle : Circle_interface
        {
    
            private int _radius;
            private Point _position;
            private bool _autoRedeye;
    
            public int Radius
            {
                get { return _radius; }
                set { _radius = value; }
            }
    
    
            public int X
            {
                get { return _position.X; }
                set { _position.X = value; }
            }
    
    
            public int Y
            {
                get { return _position.Y; }
                set { _position.Y = value; }
            }
        }
    
    
    }
