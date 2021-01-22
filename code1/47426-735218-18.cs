    template <class T>
    class ImageMatrix
    {
    public:
    	T GetRotatedMatrix()
    	{
    		return T();
    	}
    };
    
    class ImageFilter : public ImageMatrix<ImageFilter>
    {
    };
    
    int main()
    {
    	ImageFilter filterPrototype;
    	ImageFilter otherFilter = filterPrototype.GetRotatedMatrix();
    }
