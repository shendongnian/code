        uint value;
        if (!uint.TryParse(label16.Text, 
               System.Globalization.NumberStyles.HexNumber, null, out value)) {
            MessageBox.Show("Invalid hex value");
            return;
        }
        serialPort1.Write(BitConverter.GetBytes(value), 0, 3);
