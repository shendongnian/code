    using (WordprocessingDocument myDocument = WordprocessingDocument.Open(fileName, true)) {
				// Get the first paragraph.
				
				Paragraph p = myDocument.MainDocumentPart.Document.Body.Elements<Paragraph>().First();
				Run r = p.Elements<Run>().First();
				Drawing drawing1 = r.Elements<Drawing>().First();
				DW.Inline inline1 = drawing1.Elements<DW.Inline>().First();
				A.Graphic graphic1 = inline1.Elements<A.Graphic>().First();
				A.GraphicData graphicData1 = graphic1.Elements<A.GraphicData>().First();
				PIC.Picture picture1 = graphicData1.Elements<PIC.Picture>().First();
				PIC.ShapeProperties shapeProperties1 = picture1.Elements<PIC.ShapeProperties>().First();
				A.Outline outline1 = shapeProperties1.Elements<A.Outline>().First();
				A.NoFill noFillOutline = outline1.Elements<A.NoFill>().First();
				noFillOutline.Remove();
				
				outline1.AppendChild(new A.GradientFill(
					new A.GradientStopList(
						new A.GradientStop(
							new A.SchemeColor(
								new A.LuminanceModulation() { Val = 5000 },
								new A.LuminanceOffset() { Val = 95000 }
							) { Val = A.SchemeColorValues.Accent1 }
						) { Position = 0 },
						new A.GradientStop(
							new A.SchemeColor(
								new A.LuminanceModulation() { Val = 45000 },
								new A.LuminanceOffset() { Val = 55000 }
							) { Val = A.SchemeColorValues.Accent1 }
						) { Position = 74000 },
						new A.GradientStop(
							new A.SchemeColor(
								new A.LuminanceModulation() { Val = 45000 },
								new A.LuminanceOffset() { Val = 55000 }
							) { Val = A.SchemeColorValues.Accent1 }
						) { Position = 83000 },
						new A.GradientStop(
							new A.SchemeColor(
								new A.LuminanceModulation() { Val = 30000 },
								new A.LuminanceOffset() { Val = 70000 }
							) { Val = A.SchemeColorValues.Accent1 }
						) { Position = 100000 }),
					new A.LinearGradientFill() {
						Angle = 5400000,
						Scaled = true
					}
				));
