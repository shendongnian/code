            var items = container.Resolve<IEnumerable<IItem<string>>>();
            foreach (var item in items)
            {
                var repository = container.Resolve(typeof (IRepository<DataItemBase>), new TypedParameter(item.GetType(), item));
                Assert.IsNotNull(repository);
            }
