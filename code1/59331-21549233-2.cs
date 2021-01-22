    using System.Diagnostics;
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                {
                    var converter = new Base10Converter(
                        digits: "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz",
                        shouldSupportRoundTripping: true
                        );
                    long number = converter.StringToBase10("Atoz");
                    string text = converter.Base10ToString(number);
                    Debug.Assert(text == "Atoz");
                }
                {
                    var converter = new HexNumberConverter();
                    string text = converter.Base10ToString(255);
                    long number = converter.StringToBase10(text);
                    Debug.Assert(number == 255);
                }
            }
        }
    }
