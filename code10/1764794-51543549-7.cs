    using System;
    using System.Windows.Forms;
    
    namespace VisualStudioLikeControls
    {
        static class misc
        {
            /// <summary> Essentially ... clamp </summary>
            public static int LimitToRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
            {
                if (value < inclusiveMinimum) { return inclusiveMinimum; }
                if (value > inclusiveMaximum) { return inclusiveMaximum; }
                return value;
            }
    
            /// <summary> Swap function that uses <Generics>. </summary>
            public static void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b; b = temp;
            }
    
            /// <summary> Converts the <Tag> property of a control to an integer. </summary>
            public static int TagToInt(object inObject) => Convert.ToInt32((inObject as Control).Tag);
        }
    }
