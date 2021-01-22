    [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase image)
        {
           Foo foo=new Foo();
           if (image != null)
                {
                    foo.ImageMimeType = image.ContentType;//public string ImageMimeType { get; set; }
                    foo.ImageData = new byte[image.ContentLength];//public byte[] ImageData { get; set; }
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                fooRepository.Save(foo);
            }
        }
