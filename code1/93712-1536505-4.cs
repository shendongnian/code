    using System;
    using System.Collections.Generic;
    using System.Text;
    using System;
    using System.Data;
    
    using System.Collections.Generic;
    using System.Collections;
    using System.IO;
    using System.Xml.Serialization;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace SaveControls
    {
        [Serializable()]
        public class CDrawing
        {
            public enum ControlTypes { Label, TextBox, None };
    
            private ControlTypes _controlType;
        public ControlTypes ControlType
        { get { return _controlType; } }
        private string _strControlText;
        public string Text
        { get { return _strControlText; } }
        private int _xPosition;
        public int X
        { get { return _xPosition; } }
        private int _yPosition;
        public int Y
        { get { return _yPosition; } }
        private string _strFontName;
        public string Font
        { get { return _strFontName; } }
        double _fFontSize;
        public double Size
        { get { return _fFontSize; } }
        string _strStyle;
        public string Style
        { get { return _strStyle; } }
        decimal _dForegroundColor;
        public decimal Color
        { get { return _dForegroundColor; } }
        public CDrawing(ControlTypes controlType, string strControlText, int xPosition, int yPosition,
        string strFontName, double fFontSize, string strStyle, decimal dForegroundColor)
        {
            _controlType = controlType;
            _strControlText = strControlText;
            _xPosition = xPosition;
            _yPosition = yPosition;
            _strFontName = strFontName;
            _fFontSize = fFontSize;
            _strStyle = strStyle;
            _dForegroundColor = dForegroundColor;
            
        }
        public void Draw(Form frm)
        {
            if (_controlType == ControlTypes.Label)
            {
                Label lbl = new Label();
                lbl.Text = _strControlText;
                lbl.Location = new Point(_xPosition, _yPosition);
                System.Drawing.FontStyle fs = (_strStyle == System.Drawing.FontStyle.Regular.ToString()) ? System.Drawing.FontStyle.Regular : System.Drawing.FontStyle.Bold;
                lbl.Font = new System.Drawing.Font(_strFontName, (float)_fFontSize, fs);
                lbl.ForeColor = SystemColors.Control;// _dForegroundColor;
                lbl.Visible = true;
                frm.Controls.Add(lbl);
            }
        }
        
    }
