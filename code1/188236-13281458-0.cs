    public Split(String[] args)
		{
			if (args.Length != 4) 
			{
				Console.Error.WriteLine("This tools needs 4 parameters:\njava Split srcfile destfile1 destfile2 pagenumber");
			}
			else 
			{
				try 
				{
					int pagenumber = int.Parse(args[3]);
                
					// we create a reader for a certain document
					PdfReader reader = new PdfReader(args[0]);
					// we retrieve the total number of pages
					int n = reader.NumberOfPages;
					Console.WriteLine("There are " + n + " pages in the original file.");
                
					if (pagenumber < 2 || pagenumber > n) 
					{
						throw new DocumentException("You can't split this document at page " + pagenumber + "; there is no such page.");
					}
                
					// step 1: creation of a document-object
					Document document1 = new Document(reader.GetPageSizeWithRotation(1));
					Document document2 = new Document(reader.GetPageSizeWithRotation(pagenumber));
					// step 2: we create a writer that listens to the document
					PdfWriter writer1 = PdfWriter.GetInstance(document1, new FileStream(args[1], FileMode.Create));
					PdfWriter writer2 = PdfWriter.GetInstance(document2, new FileStream(args[2], FileMode.Create));
					// step 3: we open the document
					document1.Open();
					PdfContentByte cb1 = writer1.DirectContent;
					document2.Open();
					PdfContentByte cb2 = writer2.DirectContent;
					PdfImportedPage page;
					int rotation;
					int i = 0;
					// step 4: we add content
					while (i < pagenumber - 1) 
					{
						i++;
						document1.SetPageSize(reader.GetPageSizeWithRotation(i));
						document1.NewPage();
						page = writer1.GetImportedPage(reader, i);
						rotation = reader.GetPageRotation(i);
						if (rotation == 90 || rotation == 270) 
						{
							cb1.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
						}
						else 
						{
							cb1.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
						}
					}
					while (i < n) 
					{
						i++;
						document2.SetPageSize(reader.GetPageSizeWithRotation(i));
						document2.NewPage();
						page = writer2.GetImportedPage(reader, i);
						rotation = reader.GetPageRotation(i);
						if (rotation == 90 || rotation == 270) 
						{
							cb2.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
						}
						else 
						{
							cb2.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
						}
						Console.WriteLine("Processed page " + i);
					}
					// step 5: we close the document
					document1.Close();
					document2.Close();
				}
				catch(Exception e) 
				{
					Console.Error.WriteLine(e.Message);
					Console.Error.WriteLine(e.StackTrace);
				}
			}
		}
