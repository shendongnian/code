    public abstract class VotingSpecs
    {
        protected static Post CreatePostWithNumberOfVotes(int votes)
        {
            var post = PostFakes.VanillaPost();
            post.Votes = votes;
            return post;
        }
    
        protected static Controller CreateVotingController()
        {
            // ...
        }
    
        protected static void TheCurrentUserVotedUpFor(Post post)
        {
            // ...
        }
    }
    
    [Subject(typeof(SomeController), "upvoting")]
    public class When_a_user_clicks_the_vote_up_button_on_a_post : VoteSetup
    {
        static Post Post;
        static Controller Controller;
        static Result Result ;
    
        Establish context = () =>
        {
            Post = CreatePostWithNumberOfVotes(0);
    
            Controller = CreateVotingController();
        };
    
        Because of = () => { Result = Controller.VoteUp(1); };
    
        It should_increment_the_votes_of_the_post_by_1 =
            () => Post.Votes.ShouldEqual(1);
    }
    
    
    [Subject(typeof(SomeController), "upvoting")]
    public class When_a_user_repeatedly_clicks_the_vote_up_button_on_a_post : VoteSetup
    {
        static Post Post;
        static Controller Controller;
        static Result Result ;
    
        Establish context = () =>
        {
            Post = CreatePostWithNumberOfVotes(1);
            TheCurrentUserVotedUpFor(Post);
    
            Controller = CreateVotingController();
        };
    
        Because of = () => { Result = Controller.VoteUp(1); };
    
        It should_not_increment_the_votes_of_the_post_by_1 =
            () => Post.Votes.ShouldEqual(1);
    }
    
    // Repeat for VoteDown().
