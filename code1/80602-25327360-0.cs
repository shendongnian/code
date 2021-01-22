    UpdateImage(string rotationAngle) {
                double d;
                double.TryParse(rotationAngle,
                                System.Globalization.NumberStyles.Number,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out d);
