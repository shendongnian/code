    public T GetSource<T>() where T : IConnection
            {
                Type listType = typeof(T);
                if (listType == typeof(SomebaseWrapper))
                {
                    return new SomebaseWrapper(_connection.GetSource<SomeBase>());
                }
                if (listType == typeof(ExternalBaseWrapper))
                {
                    return new (ExternalBaseWrapper)(_exconnection.GetSource<T>());
                }
                throw new Exception("Not supported");
            }
