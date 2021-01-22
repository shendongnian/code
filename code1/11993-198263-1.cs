        [Test]
        public void Can_get_table_name()
        {
            var attribs = typeof(Article).GetCustomAttributes(typeof(Castle.ActiveRecord.ActiveRecordAttribute), false);
            if (attribs != null)
            {
                var attrib = (Castle.ActiveRecord.ActiveRecordAttribute) attribs[0];
                Assert.AreEqual("NewsMaster", attrib.Table);
            }
        }
