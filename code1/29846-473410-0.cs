    using System.Windows.Forms;
    using System.Drawing;
    
    namespace Toolset.Controls
    {
        public class CustomDrawListBox : ListBox
        {
            public CustomDrawListBox()
            {
                this.DrawMode = DrawMode.OwnerDrawVariable; // We're using custom drawing.
                this.ItemHeight = 40; // Set the item height to 40.
            }
    
            protected override void OnDrawItem(DrawItemEventArgs e)
            {
                // Make sure we're not trying to draw something that isn't there.
                if (e.Index >= this.Items.Count || e.Index <= -1)
                    return;
    
                // Get the item object.
                object item = this.Items[e.Index];
                if (item == null)
                    return;
    
                // Draw the background color depending on 
                // if the item is selected or not.
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    // The item is selected.
                    // We want a blue background color.
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                }
                else
                {
                    // The item is NOT selected.
                    // We want a white background color.
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }
    
                // Draw the item.
                string text = item.ToString();
                SizeF stringSize = e.Graphics.MeasureString(text, this.Font);
                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.White),
                    new PointF(5, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2));
            }
        }
    }
