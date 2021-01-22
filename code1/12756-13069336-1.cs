        public long SizeOfSomeObject()
        {
            var measure = new MeasureSize<SomeObject>(() => new SomeObject());
            return measure.GetByteSize();
        }
