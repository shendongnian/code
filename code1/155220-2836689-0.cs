    public abstract class SomeControllerContext
    {
    	protected static SomeController controller;
    	protected static User user;
    	protected static ActionResult result;
    	protected static Mock<ISession> session;
    	protected static Post post;
    
    	Establish context = () =>
    	{
    		session = new Mock<ISession>();
                // some more code
    	}
    }
    /* many other specs based on SomeControllerContext here */
    [Subject(typeof(SomeController))]
    public abstract class VoteSetup : SomeControllerContext
    {
    	Establish context = () =>
    	{
    		post= PostFakes.VanillaPost();
    
    		session.Setup(s => s.Single(Moq.It.IsAny<Expression<Func<Post, bool>>>())).Returns(post);
    		session.Setup(s => s.CommitChanges());
    	};
    }
    
    [Subject(typeof(SomeController))]
    public class When_user_clicks_the_vote_up_button_on_a_post : VoteSetup
    {
    	Because of = () => result = controller.VoteUp(1);
    
    	It should_increment_the_votes_of_the_post_by_1 = () => post.Votes.ShouldEqual(11);
        It should_not_let_the_user_vote_more_than_once;
    }
    
    [Subject(typeof(SomeController))]
    public class When_user_clicks_the_vote_down_button_on_a_post : VoteSetup
    {
    	Because of = () => result = controller.VoteDown(1);
    
    	It should_decrement_the_votes_of_the_post_by_1 = () => post.Votes.ShouldEqual(9);
    	It should_not_let_the_user_vote_more_than_once;
    }
