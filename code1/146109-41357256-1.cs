     Thread thread = new Thread(() =>
                    {
                        foreach (var pic in ws.Pictures())
                        {
                            if (pic != null)
                            {
                                //This code will detect what the region span of the image was
                                int startCol = pic.TopLeftCell.Column;
                                int startRow = pic.TopLeftCell.Row;
                                int endCol = pic.BottomRightCell.Column;
                                int endRow = pic.BottomRightCell.Row;
                                pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                                if (Clipboard.GetDataObject() != null)
                                {
                                    Image img = Clipboard.GetImage();
                                }
                            }
                        }
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    //Set the thread to STA
                    thread.Start();
                    thread.Join();
