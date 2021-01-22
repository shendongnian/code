        [Fact]
        public void CanAddManyPointDs()
        {
            var points = new[]{
                new PointD( 1,1),
                new PointD( 2,3),
                new PointD( 3,4),
            };
            var result = points.Aggregate((p1, p2) => new PointD(p1.X + p2.X, p1.Y + p2.Y));
            Assert.Equal(result.X,6);
            Assert.Equal(result.Y,8);
        }
