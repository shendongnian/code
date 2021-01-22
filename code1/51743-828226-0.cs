    [TestFixture]
    public class EntityTest {
        [Test]
        public void testMovement() {
            float speed = 1.0f; // units per second
            float updateDuration = 1.0f; // seconds
            Vector2 moveVector = new Vector2(0f, 1f);
            Vector2 originalPosition = new Vector2(8f, 12f);
            Entity entity = new Entity("testGuy");
            entity.NextStep = moveVector;
            entity.Position = originalPosition;
            entity.Speed = speed;
            /*** Look ma, no Game! ***/
            entity.Update(updateDuration);
            Vector2 moveVectorDirection = moveVector;
            moveVectorDirection.Normalize();
            Vector2 expected = originalPosition +
                (speed * updateDuration * moveVectorDirection);
            float epsilon = 0.0001f; // using == on floats: bad idea
            Assert.Less(Math.Abs(expected.X - entity.Position.X), epsilon);
            Assert.Less(Math.Abs(expected.Y - entity.Position.Y), epsilon);
        }
    }
