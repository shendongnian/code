    void MyTestMethod() {
        TransparencyKey = Color.FromArgb(128, 128, 64);
        BackColor = Color.FromArgb(128, 128, 71);
    
        byte tR = ConvertR(TransparencyKey.R);
        byte tG = ConvertG(TransparencyKey.G);
        byte tB = ConvertB(TransparencyKey.B);
    
        byte bR = ConvertR(BackColor.R);
        byte bG = ConvertG(BackColor.G);
        byte bB = ConvertB(BackColor.B);
    
        if (tR == bR &&
            tG == bG &&
            tB == bB) {
            MessageBox.Show("Equal: " + tR + "," + tG + "," + tB + "\r\n" +
                bR + "," + bG + "," + bB);
        }
        else {
            MessageBox.Show("NOT Equal: " + tR + "," + tG + "," + tB + "\r\n" +
                bR + "," + bG + "," + bB);
        }
    }
    byte ConvertR(byte colorByte) {
        return (byte)(((double)colorByte / 256.0) * 32.0);
    }
    byte ConvertG(byte colorByte) {
        return (byte)(((double)colorByte / 256.0) * 64.0);
    }
    byte ConvertB(byte colorByte) {
        return (byte)(((double)colorByte / 256.0) * 32.0);
    }
