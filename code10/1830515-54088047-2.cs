    namespace AndroidJunior
    {
        public class RotatedTextView : View
        {
            //private int mColor = Color.Red;
            private String mText = "I am a Custom TextView sdsdasdasdsa";
            private Paint mPaint = new Paint(PaintFlags.AntiAlias);
    
            public RotatedTextView(Context context) : base(context)
            { 
            }
    
            public RotatedTextView(Context context, IAttributeSet attrs) : base(context, attrs,0)
            {
                TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.RotatedTextView);
                //mColor = typedArray.GetColor(Resource.Styleable.RotatedTextView_customColor, Color.Red);
                if (typedArray.GetText(Resource.Styleable.RotatedTextView_customText) != null)
                {
                    mText = typedArray.GetText(Resource.Styleable.RotatedTextView_customText).ToString();
                }
                typedArray.Recycle();
            }
    
            public RotatedTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
            {
            }
    
    
            protected override void OnDraw(Canvas canvas)
            {
                base.OnDraw(canvas);
                canvas.DrawText(mText, 100, 100, mPaint);
            }
        }
    }
