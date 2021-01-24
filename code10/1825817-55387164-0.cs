        [Fact]
        public void JourneyTypesModelBinderTest()
        {
            var bindingContext = new DefaultModelBindingContext();
            var bindingSource = new BindingSource("", "", false, false);
            var routeValueDictionary = new RouteValueDictionary
            {
                {"IsSingleWay", true},
                {"JourneyType", "Single"}
            };
            bindingContext.ValueProvider = new RouteValueProvider(bindingSource, routeValueDictionary);
            var binder = new JourneyTypesModelBinder();
            binder.BindModelAsync(bindingContext);
            Assert.True(bindingContext.Result.IsModelSet);
            Assert.Equal(JourneyTypes.Single, bindingContext.Result.Model);
        }
