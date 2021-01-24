    public abstract class Card
    {
            public Card(Suit suit, Value value)
            {
                Suit = suit;
                Value = value;
            }
            public abstract Suit Suit { get; }
            public abstract Value Value { get; }
    }
        
    public class CardEntity : Card
    {
        private readonly Position _position;
        private readonly Card _card;
        public CardEntity(GraphicsDevice graphicsDevice, Card card) 
        {
            _position = new Position();
            _card = card;
        }
        public Suit Suit => _card.Suit;
        public Value Value => _card.Value;
        public void Draw(SpriteBatch spriteBatch)
        {
            var topLeftOfSprite = new Vector2(_position.X, _position.Y);
            var sourceRectangle = new Rectangle
            {
                X = XPosOnSpriteSheet,
                Y = YPosOnSpriteSheet,
                Height = CardTextureHeight,
                Width = CardTextureWidth - Offset
            };
            spriteBatch.Draw(_cardsSheetTexture, topLeftOfSprite, sourceRectangle, XnaColor.White);
        }
    }
