    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Nik.UserControls
    {
        public class RicherTextBox2 : System.Windows.Forms.RichTextBox
        {
            public event EventHandler CursorPositionChanged;
            
            protected virtual void OnCursorPositionChanged( EventArgs e )
            {
                if ( CursorPositionChanged != null )
                    CursorPositionChanged( this, e );
            }
    
            protected override void OnSelectionChanged( EventArgs e )
            {
                if ( SelectionLength == 0 )
                    OnCursorPositionChanged( e );
                else
                    base.OnSelectionChanged( e );
            }
                
            public int CurrentColumn
            {
                get { return CursorPosition.Column( this, SelectionStart ); }
            }
    
            public int CurrentLine
            {
                get { return CursorPosition.Line( this, SelectionStart ); }
            }
    
            public int CurrentPosition
            {
                get { return this.SelectionStart; }
            }
    
            public int SelectionEnd
            {
                get { return SelectionStart + SelectionLength; }
            }
        }
        
        internal class CursorPosition
        {
            [System.Runtime.InteropServices.DllImport("user32")] 
            public static extern int GetCaretPos(ref Point lpPoint);
    
            private static int GetCorrection(RichTextBox e, int index)
            {
                Point pt1 = Point.Empty;
                GetCaretPos(ref pt1);
                Point pt2 = e.GetPositionFromCharIndex(index);
    
                if ( pt1 != pt2 )
                    return 1;
                else
                    return 0;
            }
    
            public static int Line( RichTextBox e, int index )
            {
                 int correction = GetCorrection( e, index );
                 return e.GetLineFromCharIndex( index ) - correction + 1;
            }
    
            public static int Column( RichTextBox e, int index1 )
            {
                 int correction = GetCorrection( e, index1 );
                 Point p = e.GetPositionFromCharIndex( index1 - correction );
    
                 if ( p.X == 1 )
                     return 1;
    
                 p.X = 0;
                 int index2 = e.GetCharIndexFromPosition( p );
    
                 int col = index1 - index2 + 1;
    
                 return col;
             }
        }
    }
