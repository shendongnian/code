    this.comboPortName.Items.AddRange(
        (from qP in System.IO.Ports.SerialPort.GetPortNames()
         orderby System.Text.RegularExpressions.Regex.Replace(qP, "~\\d",
         string.Empty).PadLeft(6, '0')
         select qP).ToArray()
    );
