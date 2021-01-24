    using System.Collections.Generic;
    ...
    namespace ...
    {
	    public class CardDrawingVisitor : Visitor
	    {
		    private readonly SpriteBatch _spriteBatch;
		    private readonly PngHandler _cardPng;
		    private readonly Stack<Card> _result = new Stack<Card>();
		    public CardDrawingVisitor(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
		    {
			    _spriteBatch = spriteBatch;
			    _cardPng = new PngHandler(graphicsDevice, "cards");
		    }
		    public override void Visit(Card card)
		    {
			    _result.Push(card);
		    }
 
		    public void Draw()
		    {
			    var cardNumber = 0;
			    foreach (var card in _result)
			    {
				    _cardPng.Draw(_spriteBatch, card, cardNumber++, 0);
			    }
		    }  
	    }
    }
