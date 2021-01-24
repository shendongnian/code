    if (File.Exists(pathPoster + fileName))
                            {
                                seriePopular.btnSerie.Image = Image.FromFile(pathPoster + fileName);
                            }
                            else
                            {
                                Uri url = client.GetImageUrl(client.Config.Images.PosterSizes.Last(), searchSerie.PosterPath);
                                byte[] imageData = wcGreatest.DownloadData(url);
                                File.WriteAllBytes(pathPoster + fileName, imageData);
                                seriePopular.btnSerie.Image = Image.FromFile(pathPoster + fileName);
                            }
