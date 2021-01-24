    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Google.Cloud.Vision.V1;
    using Google.Apis.Auth.OAuth2;
    using Image = Google.Cloud.Vision.V1.Image;
    
    
    namespace DLL_TEST_NetFramework4._6._1version
    {
        public class Class1
        {
            public string doc_text_dection(string GVA_File_Path, string Credential_Path)
            {
                //var credential = GoogleCredential.FromFile(Credential_Path);
    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "Your_Json_File_Name.json");
                //Load the image file into memory
                var image = Image.FromFile(GVA_File_Path);    
    
                // Instantiates a client
                ImageAnnotatorClient client = ImageAnnotatorClient.Create();
    
                TextAnnotation text = client.DetectDocumentText(image);
                //Console.WriteLine($"Text: {text.Text}");
    
                return $"Text: {text.Text}";
                //return "test image...";
            }
        }
    }
