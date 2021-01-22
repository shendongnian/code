    public Bitmap GetCurrentImage()
            {
                Bitmap bmp = null;
                if (windowlessCtrl != null)
                {
                    IntPtr currentImage = IntPtr.Zero;
    
                    try
                    {
                        int hr = windowlessCtrl.GetCurrentImage(out currentImage);
                        DsError.ThrowExceptionForHR(hr);
    
                        if (currentImage != IntPtr.Zero)
                        {
                            BitmapInfoHeader structure = new BitmapInfoHeader();
                            Marshal.PtrToStructure(currentImage, structure);
    
                            PixelFormat pixelFormat = PixelFormat.Format24bppRgb;
                            switch (structure.BitCount)
                            {
                                case 24:
                                    pixelFormat = PixelFormat.Format24bppRgb;
                                    break;
                                case 32:
                                    pixelFormat = PixelFormat.Format32bppRgb;
                                    break;
                                case 48:
                                    pixelFormat = PixelFormat.Format48bppRgb;
                                    break;
                                default:
                                    throw new Exception("BitCount desconhecido");
                            }
    
                            // este trecho: new IntPtr(currentImage.ToInt64() + 40), é o que resolve o problema da faixa (strip) da direita na esquerda.
                            bmp = new Bitmap(structure.Width, structure.Height, (structure.BitCount / 8) * structure.Width, pixelFormat, new IntPtr(currentImage.ToInt64() + 40));
                            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }
                    }
                    catch (Exception anyException)
                    {
                        MessageBox.Show("Falha gravando imagem da Webcam: " + anyException.ToString());
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(currentImage);
                    }
                }
                return bmp;
            }
