    public class WidgetPlatform
        {
            /// <summary>
            /// Hide the constructor.
            /// </summary>
            private WidgetPlatform(Widget left, Widget right)
            {
                this.LeftmostWidget = left;
                this.RightmostWidget = right;
            }
    
            public Widget LeftmostWidget
            {
                get;
                private set;
            }
    
            public Widget RightmostWidget
            {
                get;
                private set;
            }
    
            public static WidgetPlatform GetInstance(Widget left, Widget right)
            {
                return new WidgetPlatform(left, right);
            }
        }
