using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace NumberedTextBoxLib {
  public partial class NumberedTextBox : UserControl {
    private int lineIndex = 0;
    public override String Text {
      get {
        return editBox.Text;
      }
      set {
        editBox.Text = value;
      }
    }
    public NumberedTextBox() {
      InitializeComponent();
      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw, true);
      editBox.SelectionChanged += new EventHandler(selectionChanged);
      editBox.VScroll += new EventHandler(OnVScroll);
    }
    private void selectionChanged(object sender, EventArgs args) {
      FindLine();
      Invalidate();
    }
    private void FindLine() {
      int charIndex = editBox.GetCharIndexFromPosition(new Point(0, 0));
      lineIndex = editBox.GetLineFromCharIndex(charIndex);
    }
    private void DrawLines(Graphics g) {
      int counter, y;
      g.Clear(BackColor);
      counter = lineIndex + 1;
      y = 2;
      int max = 0;
      while (y &lt; ClientRectangle.Height - 15) {
        SizeF size = g.MeasureString(counter.ToString(), Font);
        g.DrawString(counter.ToString(), Font, new SolidBrush(ForeColor), new Point(3, y));
        counter++;
        y += (int)size.Height;
        if (max &lt; size.Width) {
          max = (int) size.Width;
        }
      }
      max += 6;
      editBox.Location = new Point(max, 0);
      editBox.Size = new Size(ClientRectangle.Width - max, ClientRectangle.Height);
    }
    protected override void OnPaint(PaintEventArgs e) {
      DrawLines(e.Graphics);
      e.Graphics.TranslateTransform(50, 0);
      editBox.Invalidate();
      base.OnPaint(e);
    }
    ///Redraw the numbers when the editor is scrolled vertically
    private void OnVScroll(object sender, EventArgs e) {
      FindLine();
      Invalidate();
    }
  }
}
