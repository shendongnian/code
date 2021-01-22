		public static class TestClass {
			public static void TestMethod() {
				Entity entity = new Entity((IntPtr)0x1234);
				Body body = (Entity.To<Body>)entity;
				Context context = (Body.To<Context>)body;
			}
		}
