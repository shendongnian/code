        static void Main()
        {
            var addressList = "line one~line two~line three~postcode";
            var address = new XElement("Address");
            var addressHtml = "<span>" + addressList.Replace("~", "<br />") + "</span>";
            XElement content;
            if (MyXElement.TryParse(addressHtml, out content))
                address.ReplaceAll(content);
            else
                address.SetValue(addressHtml);
            Console.WriteLine(address.ToString());
            Console.ReadKey();
        }
    }
