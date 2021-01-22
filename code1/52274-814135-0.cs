        public void Initialize()
        {
            var container = new Container(x => x.ForRequestedType<ITracker>().TheDefaultIsConcreteType<MultiTracker>().OnCreation(y => ((MultiTracker)y).Trackers = new ITracker[]
                                                                                                                                                                        {
                                                                                                                                                                            new ConcreteType1(), new ConcreteType2()
                                                                                                                                                                        }));
            //Run a test - this explodes
            container.GetInstance<ITracker>();
        }
        public class MultiTracker : ITracker
        {
            public ITracker[] Trackers { get; set; }
        }
