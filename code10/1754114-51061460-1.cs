    [HttpPost]
    public IActionResult CreateOrder(OrderViewModel ovm)
    {
        var order = ovm.Order;
        if (ovm.File != null)
        {
            byte[] fileData = null;
            // read file to byte array
            using (var binaryReader = new BinaryReader(ovm.File.OpenReadStream()))
            {
                fileData = binaryReader.ReadBytes((int)ovm.File.Length);
            }
        }
    }
