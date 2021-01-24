    private Stylesheet GenerateStylesheet1()
            {
                Stylesheet styleSheet = null;
    
                Fonts fonts = new Fonts(
                    new Font(
                        new FontSize() { Val = 10 },
                        new Bold(),
                        new Color() { Rgb = "FFFFFF" }
    
                    ));
    
                Fills fills = new Fills(
                        new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "66666666" } })
                        { PatternType = PatternValues.Solid })
                    );
    
                Borders borders = new Borders(
                        new Border(
                            new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                            new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                            new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                            new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                            new DiagonalBorder())
                    );
    
                CellFormats cellFormats = new CellFormats(
                        new CellFormat(),
                        new CellFormat { FontId = 0, FillId = 0, BorderId = 0, ApplyFill = true }
                    );
    
                styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);
    
                return styleSheet;
            }
    
