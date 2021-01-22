	#include "Constants.h"
	namespace ConstantBridge { public ref class ConstantBridge {
	public:
		// The use of the `literal` keyword is important
		// `static const` will not work
		literal int kMagicNumber = Constants::MAGIC_NUMBER;
		literal String ^ kMagicPhrase = MAGIC_PHRASE;
	};}
