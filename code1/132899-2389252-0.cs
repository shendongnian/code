    namespace ImageConversionTest
    {
    	using System.Drawing;
    	using System.Runtime.InteropServices;
    	using System.Drawing.Imaging;
    	using System.Globalization;
    
    	class Program
    	{
    		static void Main( string[] args )
    		{
    			using( Image im = Image.FromFile( @"C:\20128X.jpg" ) )
    			{
    				string saveAs = @"C:\output.jpg";
    
    				EncoderParameters encoderParams = null;
    				ImageCodecInfo codec = GetEncoderInfo( "image/jpeg" );
    				if( codec != null )
    				{
    					int quality = 100; // highest quality
    					EncoderParameter qualityParam = new EncoderParameter( 
    						System.Drawing.Imaging.Encoder.Quality, quality );
    					encoderParams = new EncoderParameters( 1 );
    					encoderParams.Param[0] = qualityParam;
    				}
    
    				try
    				{
    					if( encoderParams != null )
    					{
    						im.Save( saveAs, codec, encoderParams );
    					}
    					else
    					{
    						im.Save( saveAs, ImageFormat.Jpeg );
    					}
    				}
    				catch( ExternalException )
    				{
    					// copy and save separately
    					using( Image temp = new Bitmap( im ) )
    					{
    						if( encoderParams != null )
    						{
    							temp.Save( saveAs, codec, encoderParams );
    						}
    						else
    						{
    							temp.Save( saveAs, ImageFormat.Jpeg );
    						}
    					}
    				}
    			}
    		}
    
    		private static ImageCodecInfo GetEncoderInfo( string mimeType )
    		{
    			// Get image codecs for all image formats
    			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
    
    			// Find the correct image codec
    			foreach( ImageCodecInfo codec in codecs )
    			{
    				if( string.Compare( codec.MimeType, mimeType, true, CultureInfo.InvariantCulture ) == 0 )
    				{
    					return codec;
    				}
    			}
    			return null;
    		}
    	}
    }
