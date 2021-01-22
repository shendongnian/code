    public interface IA
        {
            int A(int a);
        }
        public interface IB
        {
            int B(int b);
        }
        [Test]
        public void Multimocks()
        {
            MockRepository mocks = new MockRepository();
            IA mymock = mocks.DynamicMultiMock<IA>(typeof (IB));
            Expect.Call(mymock.A(1)).Return(2);
            Expect.Call(((IB)mymock).B(3)).Return(4);
            mocks.ReplayAll();
            Assert.AreEqual(2, mymock.A(1));
            Assert.AreEqual(4, ((IB)mymock).B(3));
        }
