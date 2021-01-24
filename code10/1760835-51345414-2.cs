    namespace QRmaker
    {
        class Program
        {
            public static void codeMake(string input)
            { 
                var generator = new QRCodeGenerator();
                var qrCodeData = generator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                var qrCodeImage = qrCode.GetGraphic(20);
                qrCodeImage.Save("Address.bmp");
            }
        }
    }
