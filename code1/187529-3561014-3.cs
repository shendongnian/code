    using System.Collections.ObjectModel;
    using BitMiracle.Docotic.Pdf;
    
    namespace BitMiracle.Docotic.Samples
    {
        public static class ReadComboOptions
        {
            public static void Main()
            {
                using (PdfDocument document = new PdfDocument("DocumentName.pdf"))
                {
                    PdfCollection<PdfWidget> widgets = document.Pages[0].Widgets;
                    foreach (PdfWidget widget in widgets)
                    {
                        PdfComboBox comboBox = widget as PdfComboBox;
                        if (comboBox != null)
                        {
                            foreach (string item in comboBox.Items)
                            {
                                // do something with combo box option
                            }
                        }
                    }
                }
            }
        }
    }
