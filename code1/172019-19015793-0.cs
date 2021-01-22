    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    public class CToolTip : ToolTip
    {
       protected Int32 LengthWrap { get; private set; }
       protected Control Parent { get; private set; }
       public CToolTip(Control parent, int length)
          : base()
       {
      this.Parent = parent;
      this.LengthWrap = length;
       }
       public String finalText = "";
       public void Text(string text)
       {
          var tText = text.Split(' ');
          string rText = "";
          for (int i = 0; i < tText.Length; i++)
          {
             if (rText.Length < LengthWrap)
             {
                rText += tText[i] + " ";
             }
             else
             {
                rText += "\n" + tText[i];
                finalText += rText;
                rText = " ";
             }
          }
          base.SetToolTip(Parent, finalText);
       }
    }
