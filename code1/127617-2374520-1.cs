    [TestFixture]
    public class When_asked_to_return_items_in_sets
    {
        [Test]
        public void Should_return_the_correct_number_of_sets_if_the_input_contains_a_multiple_of_the_setSize()
        {
            List<string> input = "abcdefghij".Select(x => x.ToString()).ToList();
            var result = input.InSetsOf(5);
            result.Count().ShouldBeEqualTo(2);
            result.First().Count.ShouldBeEqualTo(5);
            result.Last().Count.ShouldBeEqualTo(5);
        }
        [Test]
        public void Should_separate_the_input_into_sets_of_size_requested()
        {
            List<string> input = "abcdefghijklm".Select(x => x.ToString()).ToList();
            var result = input.InSetsOf(5);
            result.Count().ShouldBeEqualTo(3);
            result.First().Count.ShouldBeEqualTo(5);
            result.Last().Count.ShouldBeEqualTo(3);
        }
    }        
