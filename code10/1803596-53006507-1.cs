    using System;
    using System.Linq;
    using HtmlAgilityPack;
    namespace HtmlAgilityPackDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string html = @"<h1 class=""c-product__title"">
        هندزفری بلوتوث مدل HBQ-I7
                    <span>HBQ-I7 Bluetooth Handsfree</span></h1>";
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                var text = (from node in doc.DocumentNode.ChildNodes
                    let textNode = node.SelectSingleNode("//text()") // selects the text 
                    let spanNode = node.SelectSingleNode("span")
                    select new 
                    {
                        PersianText = textNode.InnerText.Trim(),
                        EnglishText = spanNode.InnerText.Trim()
                    })
                    .FirstOrDefault();
                Console.Read();
            }
        }
    }
