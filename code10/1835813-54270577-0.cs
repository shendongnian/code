    [Fact]
        public void Search_EmptyParametersPassed_ReturnsError400()
        {
            // Act
            _controller.ModelState.AddModelError("Title", "Required");
            var result = _controller.Search(new MovieFilters());
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
