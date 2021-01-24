    ResizeBilinear resizeBilinear = new ResizeBilinear(200, 200);
            bitmapConverted = resizeBilinear.Apply(bitmapConverted);
            bitMapTemplate = resizeBilinear.Apply(bitMapTemplate);
            //comparing our to bmp
            TemplateMatch[] templateMatcheArray = exhaustiveTemplateMatching.ProcessImage(bitmapConverted, bitMapTemplate);
