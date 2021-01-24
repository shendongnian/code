    [TestMethod]
        public void TestVM()
        {
            Mock<IExternalEntities> m_externalEntities = new Mock<IExternalEntities>();
            Mock<IReflection> m_reflection = new Mock<IReflection>();
            Mock<IVm> m_vm = new Mock<IVm>();
            m_externalEntities.Setup(x => x.Reflaction).Returns(m_reflection.Object);
            m_reflection.Setup(x => x.VM).Returns(m_vm.Object);
            var testee = new VM(m_externalEntities.Object);
            var ans = testee.IsVmPowerOn();
            Assert.IsTrue(ans);
        }
