            MyComplexObject dto = new MyComplexObject();
            MemoryStream mem = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                b.Serialize(mem, dto);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
