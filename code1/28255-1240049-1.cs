    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Click_submitButton(object sender, EventArgs e)
        {
            if (myUpload.HasFile && isUploadAJpeg(myUpload.PostedFile))
            {
                System.Drawing.Bitmap uploadedImage = new System.Drawing.Bitmap(myUpload.PostedFile.InputStream);
                if (isFileACMYKJpeg(uploadedImage))
                {
                    feedback.Text = "The file is a CYMK jpg";
                }
                else
                {
                    feedback.Text = "This is a RGB jpg";
                    //it is a rgb jpg --> do something with it
                }
            }
            else
            {
                feedback.Text = "You did not upload a jpg";
            }
        }
    
        protected bool isUploadAJpeg(HttpPostedFile someFile)
        {
            if (someFile.ContentType == "image/jpg" || someFile.ContentType == "image/jpeg" || someFile.ContentType == "image/pjpeg")
            {
                return true;
            }
            return false;
        }
    
        protected bool isFileACMYKJpeg(System.Drawing.Image someImage)
        {
            System.Drawing.Imaging.ImageFlags flagValues = (System.Drawing.Imaging.ImageFlags)Enum.Parse(typeof(System.Drawing.Imaging.ImageFlags), someImage.Flags.ToString());
            if (flagValues.ToString().ToLower().IndexOf("ycck") == -1)
            {
                return false;
            }
            return true;
        }
    }
