    private void PieceClickEvent(Transform target, MouseEventType type, ref Transform pieceTarget, System.Action<Transform> onFocus, System.Action<Transform> onBlur )
    {
        if (type == MouseEventType.CLICK && canClick)>
        {
            if (pieceTarget != null && pieceTarget != target && onBlur != null )
            {
                onBlur( pieceTarget ) ;
            }
    
            if (imagePieceTarget == target.transform)
            {
                if( onBlur != null )
                    onBlur( pieceTarget ) ;
    
                pieceTarget = null;
            }
            else
            {
                pieceTarget = target;
                if( onFocus != null )
                    onFocus( pieceTarget ) ;
            }
        }
    }
    
    // ...
    
    PieceClickEvent(
        target.transform,
        type,
        ref imagePieceTarget,
        t => t.GetComponent<SpriteRenderer>().DOFade(1f, 0.2f).OnComplete(CheckAnswer),
        t => t.GetComponent<SpriteRenderer>().DOFade(0.7f, 0.2f)
    );
    
    PieceClickEvent(
        target.transform,
        type,
        ref clonePieceTarget,
        t => t.DOScale(1f, 0.2f).OnComplete(CheckAnswer),
        t => t.DOScale(0.7f, 0.2f)
    );
