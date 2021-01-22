using System;
using System.Net;
namespace Downloader
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (WebClient wc = new WebClient())
			{
				wc.DownloadFile("http://www.mydomain.com/resource.img", "c:\\savedImage.img");
			}
		}
	}
}
