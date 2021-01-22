    aspx.cs code
    protected int GetRows(object value) {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return 1;
            var contentTrimmed = value.ToString().Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Trim();
            var length = (decimal)contentTrimmed.Length;
            if (length == 0)
                return 1;
            int res = 0;
            decimal maxLength = 56;
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                 SizeF sizeRef = graphics.MeasureString("W", new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Pixel));
                 maxLength = maxLength * (decimal)sizeRef.Width;
                 SizeF size = graphics.MeasureString(contentTrimmed, new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Pixel));
                 length = (decimal)size.Width;
            }
            res = (int)Math.Round(length / (decimal)maxLength, MidpointRounding.AwayFromZero);
            if (res == 0)
                return 1;
            return res;
     }
    aspx code
    <asp:TextBox ID="txtValue" TextMode="MultiLine" Text='<%# Eval("Value") %>' runat="server" MaxLength="500" Width="700px" Rows='<%# GetRows(Eval ("Value")) %>' ></asp:TextBox>`
