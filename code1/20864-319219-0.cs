    [TestFixture] public class SomeRandomAttributeTest
    {
		[SomeRandom(RestrictionType.Local)]
		public void PlaceholderMethodForAttribute() {throw new ApplicationException(this.ToString());}
		[Test]public void BlahBlahIsBlahTheBlah()
		{
			object[] attributes = this.GetType().GetMethod("PlaceholderMethodForAttribute").GetCustomAttributes(false);
			Assert.AreEqual(1, attributes.Length);
			Assert.IsInstanceOfType(typeof(SomeRandomAttribute), attributes[0]);
			Assert.AreEqual("Yada yada yada", ((SomeRandomAttribute) attributes[0]).Yada);
		}
	}
