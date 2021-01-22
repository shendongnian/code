    /// <summary>
        /// Returns a FlowDocument in SearchableText UI Binary (SUB)String format.
        /// </summary>
        /// <param name="flowDocument">The FlowDocument containing images/UI formats to be converted</param>
        /// <returns>Returns a string representation of the FlowDocument with images in base64 string in image tag property</returns>
        private string ConvertFlowDocumentToSUBStringFormat(FlowDocument flowDocument)
        {
            //take the flow document and change all of its images into a base64 string
            FlowDocument fd = TransformImagesTo64(flowDocument);
            //apply the XamlWriter to the newly transformed flowdocument
            using (StringWriter stringwriter = new StringWriter())
            {
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(stringwriter))
                {
                    XamlWriter.Save(flowDocument, writer);
                }
                return stringwriter.ToString();
            }
        }
        /// <summary>
        /// Returns a FlowDocument with images in base64 stored in their own tag property
        /// </summary>
        /// <param name="flowDocument">The FlowDocument containing images/UI formats to be converted</param>
        /// <returns>Returns a FlowDocument with images in base 64 string in image tag property</returns>
        private FlowDocument TransformImagesTo64(FlowDocument flowDocument)
        {
            FlowDocument img_flowDocument;
            Paragraph img_paragraph;
            InlineUIContainer img_inline;
            System.Windows.Controls.Image newImage;
            Type inlineType;
            InlineUIContainer uic;
            System.Windows.Controls.Image replacementImage;
            //loop through replacing images in the flowdoc with the base64 versions
            foreach (Block b in flowDocument.Blocks)
            {
                //loop through inlines looking for images
                foreach (Inline i in ((Paragraph)b).Inlines)
                {
                    inlineType = i.GetType();
                    /*if (inlineType == typeof(Run))
                    {
                        //The inline is TEXT!!! $$$$$ Kept in case needed $$$$$
                    }
                    else */if (inlineType == typeof(InlineUIContainer))
                    {
                        //The inline has an object, likely an IMAGE!!!
                        uic = ((InlineUIContainer)i);
                        //if it is an image
                        if (uic.Child.GetType() == typeof(System.Windows.Controls.Image))
                        {
                            //grab the image
                            replacementImage = (System.Windows.Controls.Image)uic.Child;
                            
                            //create a new image to be used to get base64
                            newImage = new System.Windows.Controls.Image();
                            //clone the image from the image in the flowdocument
                            newImage.Source = replacementImage.Source;
                            //create necessary objects to obtain a flowdocument in XamlFormat to get base 64 from
                            img_inline = new InlineUIContainer(newImage);
                            img_paragraph = new Paragraph(img_inline);
                            img_flowDocument = new FlowDocument(img_paragraph);
                            //Get the base 64 version of the XamlFormat binary
                            replacementImage.Tag = TransformImageTo64String(img_flowDocument);
                        }
                    }
                }
            }
            return flowDocument;
        }
        /// <summary>
        /// Takes a FlowDocument containing a SINGLE Image, and converts to base 64 using XamlFormat
        /// </summary>
        /// <param name="flowDocument">The FlowDocument containing a SINGLE Image</param>
        /// <returns>Returns base 64 representation of image</returns>
        private string TransformImageTo64String(FlowDocument flowDocument)
        {
            TextRange documentTextRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                documentTextRange.Save(ms, DataFormats.XamlPackage);
                ms.Position = 0;
                return Convert.ToBase64String(ms.ToArray());
            }
        }
