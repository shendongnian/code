    public class TextRecyclerAdapter extends RecyclerView.Adapter<TextRecyclerAdapter.TextViewHolder> {
        ...        
        @Override
        public void onViewRecycled(@NonNull TextViewHolder holder) {
            //clear your view here
            holder.clear();
        }
        ....
    
        public static class TextViewHolder extends RecyclerView.ViewHolder {    
            ...
            public void clear(){
                //clear your view here
                _textView.setText("");
            }
    
            private TextView _textView;
            ...    
        }
